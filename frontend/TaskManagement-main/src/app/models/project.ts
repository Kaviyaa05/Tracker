// project.model.ts
export interface Project {
    ProjectId?: number; // Auto-incremented, so it's optional
    ProjectName: string;
    Priority: string;
    Description: string;
    Owner: string;
    StartDate: string;
    EndDate: string;
    Status: string;
    TeamMembers: string; // Adjusted to match your database field name
  }
  