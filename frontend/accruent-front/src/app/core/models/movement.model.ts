export type TipoMovimentacao = 'Inbound' | 'Outbound';

export interface Movement {
  productCode: string;
  type: TipoMovimentacao;
  quantity: number;
}