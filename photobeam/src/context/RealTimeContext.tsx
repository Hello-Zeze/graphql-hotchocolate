import React, { useMemo } from "react";
import { makeSignalRRealtimeService } from "../services/signalr/SignalRRealtimeService";
import { RealTimeContextOptions } from "./types";

const RealtimeContext = React.createContext<null | RealTimeContextOptions>(null);

type RealtimeContextProviderProps = {
    children: React.ReactNode;
}

export const RealtimeContextProvider: React.FC<RealtimeContextProviderProps> = ({ children }) => {
    const totalViewsSignalRService = makeSignalRRealtimeService();
    totalViewsSignalRService.consume();
    
    const contextOptions: RealTimeContextOptions = useMemo(() => {
        return {
            registeredServices: [totalViewsSignalRService]
        };
    }, [totalViewsSignalRService]);

    return <RealtimeContext.Provider value={contextOptions}>{children}</RealtimeContext.Provider>;
}

export const useRealtimeContext = () => {
    const realtimeContext = React.useContext(RealtimeContext);
    if (!realtimeContext) throw new Error("Realtime Context must be used inside a provider.");
    return realtimeContext;
}