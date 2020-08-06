export class Candidate {
  id: number;
  name: string;
  position: string;
  skills: string[];
  skillTagIds: number[];
  contract: boolean;
  available: boolean;
  match: number;
}

export class Skill {
  id: number;
  description: string;
}

export class Skills {
  skillTagIds: number[];
}

