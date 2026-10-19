import { Item } from './item';

export interface Order {
  orderId: string;
  customerName: string;
  items: Item[];
  totalAmount: number;
  createdAt: Date;
}
