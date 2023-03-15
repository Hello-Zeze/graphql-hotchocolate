import React, { useState } from "react";
import withWithRealtime, { WithRealtimeProps } from "./context/withRealtime";

export interface TotalViewsProps extends WithRealtimeProps {}

const TotalViews: React.FC<TotalViewsProps> = ({ registerEvent }) => {
    const [totalViews, setTotalViews] = useState(0);
    return (
        <div>
            <div>Total Views:</div>
            <div>{totalViews}</div>
        </div>
    );
}

export default withWithRealtime(TotalViews);