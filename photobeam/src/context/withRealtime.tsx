import React from "react";
import { useRealtimeContext } from "./RealTimeContext";
export interface WithRealtimeProps {

}

const withWithRealtime = <P extends object>(WrappedComponent: React.ComponentType<P>): 
React.FC<P & WithRealtimeProps> => ({...props}: WithRealtimeProps) => {
    const { registeredServices } = useRealtimeContext();
    registeredServices[0].
    return (
        <>
            <WrappedComponent {...props as P} />
        </>
    );
};

export default withWithRealtime;
    