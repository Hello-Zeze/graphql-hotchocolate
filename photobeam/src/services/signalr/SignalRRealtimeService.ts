import { IRealtimeService } from "../types";
import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";

export const makeSignalRRealtimeService = (): IRealtimeService => {
    return new SignalRRealtimeService();
}

class SignalRRealtimeService implements IRealtimeService {
    private readonly connection:HubConnection;
    public static inboundEvents: string[] = [
        "updatedTotalViews"
    ];
    public static outboundHubEvents: string[] = [
        "NewWindowLoaded"
    ];
    constructor() {
        const connectionUrl = "https://localhost:7281/hubs/userCount";
        this.connection = new HubConnectionBuilder()
                                .withUrl(connectionUrl)
                                .withAutomaticReconnect()
                                .build();        
    }
    
    consume = async () => {
        SignalRRealtimeService.inboundEvents.forEach(key => {
            this.connection.on(key, data => {
                dispatchEvent(new CustomEvent(key, { detail: data }));
            });
        });
        try {
            await this.connection.start();
            this.onConnectionOpened();
        } catch(e) {
            console.error(`[SignalRRealtime Service]: Error starting service. ${e}`);
        }        
    };

    onConnectionOpened = () => {
        console.log("[SignalR Service]: Connection Opened");
        this.connection.send("NewWindowLoaded");
    };
    onConnectionClosed = () => {
        console.log("[SignalR Service]: Connection Closed");
    };
}

export default SignalRRealtimeService;