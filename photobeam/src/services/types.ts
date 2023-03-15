export interface IRealtimeService {
    onConnectionOpened: () => void;
    onConnectionClosed: () => void;
};