// Поганий код
interface IItem {
    ItemId: string;
    title: string;
    price: number;
}

class badStoreInventory implements IItem {
    ItemId: string;
    title: string;
    price: number;
    constructor( id: string, t: string, p: number ) { this.ItemId = id; this.title = t; this.price = p; }
    CheckStock() { return true; }
}

// Гарний код
interface Item {
  itemId: string;
  title: string;
  price: number;
}

class GoodStoreInventory implements Item {
  constructor(
    public itemId: string,
    public title: string,
    public price: number,
  ) {}

  public checkStock(): boolean {
    return true;
  }
}
