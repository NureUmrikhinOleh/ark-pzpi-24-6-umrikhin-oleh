interface Item {
  title: string;
  price: number;
};

const MAX_DISCOUNT = 15;

/**
 * Розраховує ціну товару з урахуванням максимально дозволеної знижки у магазині.
 * 
 * @param item - Об'єкт товару, для якого проводиться розрахунок.
 * @returns Фінальна вартість товару після застосування знижки.
 */
function calculateDiscountedPrice(item: Item): number {
  return item.price - (item.price * MAX_DISCOUNT / 100);
}