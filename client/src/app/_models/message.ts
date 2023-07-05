export interface Message {
    id: number;
    senderId: number;
    senderUser: string;
    senderPhotoUrl: string;
    recipientId: number;
    recipientUser: string;
    recipientPhotoUrl: string;
    content: string;
    dateRead?: Date;
    messageSent: Date;
}