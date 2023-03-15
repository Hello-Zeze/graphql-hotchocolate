import React, { useState, useEffect } from "react";
import withWithRealtime, { WithRealtimeProps } from "./context/withRealtime";

export interface TotalViewsProps extends WithRealtimeProps {}

const TotalViews: React.FC<TotalViewsProps> = ({ registerEvent }) => {
    const [totalViews, setTotalViews] = useState("");
    useEffect(() => { // TODO: remember to handle the React 18 double useEffect thing
        if (registerEvent) {
            registerEvent("updatedTotalViews", (data:string) => {
                setTotalViews(data);
            });
        }
    }, [registerEvent]);
    return (
        <div>
            <div>Total Views:</div>
            <div>{totalViews}</div>
        </div>
    );
}

export default withWithRealtime(TotalViews);