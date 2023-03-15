import React from "react";
import { makeSignalRRealtimeService } from "../services/signalr/SignalRRealtimeService";
import { RealTimeContextOptions } from "./types";

type RealtimeContextProviderProps = {
    children: React.ReactNode;
}

export const RealtimeContextProvider: React.FC<RealtimeContextProviderProps> = ({ children }) => {
    const totalViewsSignalRService = makeSignalRRealtimeService();
    
    const contextOptions: RealTimeContextOptions = {
        registeredServices: [totalViewsSignalRService]
    };

    const RealtimeContext = React.createContext<null | RealTimeContextOptions>(null);

    return <RealtimeContext.Provider value={contextOptions}>{children}</RealtimeContext.Provider>;
}