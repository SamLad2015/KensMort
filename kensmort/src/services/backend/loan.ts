export class Loan {
  id: number;
  balance: number;
  wac: string;
  btl: number;
  LoanEndDate: string;
}

export class LoanRequest {
  portfolioIds: string;
  cutOffDate: string;
}
