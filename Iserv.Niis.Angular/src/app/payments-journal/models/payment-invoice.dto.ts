export class PaymentInvoiceDto {
  public id: number;
  public ownerId: number;
  public tariffId: number;
  public tariffNameRu: string;
  public coefficient: number;
  public tariffCount: number;
  public tariffCode: string;
  public penaltyPercent: number;
  public nds: number;
  public tariffPrice: number;
  public totalAmount: number;
  public totalAmountNds: number;
  public amountUseSum: number;
  public remainder: number;
  public statusId: number;
  public statusCode: string;
  public statusNameRu: string;
  public createDate: Date;
  public createUser: string;
  public creditDate: Date;
  public creditUser: string;
  public writeOffDate: Date;
  public writeOffUser: string;
  public deleteDate: Date;
  public deleteUser: string;
  public deletionReason: string;
  public isDeleted: boolean;
}
