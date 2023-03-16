import React from "react";
import SignalRRealtimeService from "../services/signalr/SignalRRealtimeService";
import { useRealtimeContext } from "./RealTimeContext";
export interface WithRealtimeProps {
    registerEventListener?: (eventName: string, handler: (data: string) => void) => void;
    removeEventListener?: (eventName: string) => void;
    publishEvent?: (eventName: string, data: object) => void;
}

const withWithRealtime = <P extends object>(WrappedComponent: React.ComponentType<P>): 
React.FC<P & WithRealtimeProps> => ({...props}: WithRealtimeProps) => {
    const { registeredServices } = useRealtimeContext();
    const registerEventHandler = (eventName: string, handler: (data: string) => void) => {        
        window.addEventListener(eventName, (e) => {
            const { detail } = e as CustomEvent;
            handler(detail);
        });
    };
    return (
        <>
            <WrappedComponent registerEvent={registerEventHandler} {...props as P} />
        </>
    );
};

export default withWithRealtime;
    