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

export class LoanResponse {
  loans: Loan[];
  processedLoanCount: number;
}
