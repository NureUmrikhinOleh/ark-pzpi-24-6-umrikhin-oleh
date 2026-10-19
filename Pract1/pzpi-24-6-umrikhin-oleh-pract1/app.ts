/* Без barrel файлу було б 
import { Item } from './models/item';
import { Order } from './models/order';
*/
import { Item, Order } from './models';

// Створюємо товари та замовлення
const laptopItem: Item = {
  itemId: 'ITEM-001',
  title: 'Ноутбук HP ProBook',
  price: 40000,
};

const mousepadItem: Item = {
  itemId: 'ITEM-002',
  title: 'Килимок для миші',
  price: 1000,
};

const newOrder: Order = {
  orderId: 'ORD-001',
  customerName: 'Олег Умріхін',
  items: [laptopItem, mousepadItem],
  totalAmount: 2,
  createdAt: new Date(),
};
