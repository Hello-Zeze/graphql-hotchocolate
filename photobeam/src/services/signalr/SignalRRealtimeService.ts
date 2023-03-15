import { IRealtimeService } from "../types";
import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";

export const makeSignalRRealtimeService = (): IRealtimeService => {
    return new SignalRRealtimeService();
}

class SignalRRealtimeService implements IRealtimeService {
    private readonly connection:HubConnection;
    constructor() {
        const connectionUrl = "https://localhost:7281/hubs/userCount";
        this.connection = new HubConnectionBuilder()
                                .withUrl(connectionUrl)
                                .withAutomaticReconnect()
                                .build();
        this.connection.on("updatedTotalViews", data => {
            console.log(`[SignalRRealtimeService]: ${data}`);
        });
        this.connection.start()
                        .then(() => this.onConnectionOpened())
                        .catch(err => console.error(err));
    }

    onConnectionOpened = () => {
        console.log("[SignalR Service]: Connection Opened");
        this.connection.send("NewWindowLoaded");
    };
    onConnectionClosed = () => {
        console.log("[SignalR Service]: Connection Closed");
    };
}

export default SignalRRealtimeService;