import React from "react";
import TotalViews from "./TotalViews";
import { RealtimeContextProvider } from "./context";

const App: React.FC = () => {
  return (
    <RealtimeContextProvider>
      <div className="App">
        <TotalViews />
      </div>
    </RealtimeContextProvider>
  );
}

export default App;
