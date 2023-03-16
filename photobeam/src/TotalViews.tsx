import React, { useState, useEffect, useRef } from "react";
import withWithRealtime, { WithRealtimeProps } from "./context/withRealtime";

export interface TotalViewsProps extends WithRealtimeProps {}

const TotalViews: React.FC<TotalViewsProps> = ({ registerEvent }) => {
    const registerForEvents = useRef(true);
    const [totalViews, setTotalViews] = useState("");
    const [totalUsers, setTotalUsers] = useState("");
    useEffect(() => {
        if (registerForEvents.current) {            
            if (registerEvent) {
                registerForEvents.current = false;
                registerEvent("updatedTotalViews", (data:string) => {
                    setTotalViews(data);
                });
                registerEvent("updatedTotalUsers", (data:string) => {
                    setTotalUsers(data);
                });
            }
        }
    }, [registerEvent]);
    return (
        <div>
            <div>
                <div>Total Views:</div>
                <div>{totalViews}</div>
            </div>
            <div>
                <div>Total Users:</div>
                <div>{totalUsers}</div>
            </div>
        </div>
    );
}

export default withWithRealtime(TotalViews);