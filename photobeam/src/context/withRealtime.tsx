import React from "react";
import { useRealtimeContext } from "./RealTimeContext";
export interface WithRealtimeProps {
    registerEvent?: (eventName: string, handler: (data: string) => void) => void;
}

const withWithRealtime = <P extends object>(WrappedComponent: React.ComponentType<P>): 
React.FC<P & WithRealtimeProps> => ({...props}: WithRealtimeProps) => {
    const { registeredServices } = useRealtimeContext();
    return (
        <>
            <WrappedComponent {...props as P} />
        </>
    );
};

export default withWithRealtime;
    