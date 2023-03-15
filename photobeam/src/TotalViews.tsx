import React, { useState } from "react";

const TotalViews: React.FC = () => {
    const [totalViews, setTotalViews] = useState(0);
    return (
        <div>
            <div>Total Views:</div>
            <div>{totalViews}</div>
        </div>
    );
}

export default TotalViews;