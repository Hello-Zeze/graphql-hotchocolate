export interface IRealtimeService {
    consume: () => void;
    onConnectionOpened: () => void;
    onConnectionClosed: () => void;
};