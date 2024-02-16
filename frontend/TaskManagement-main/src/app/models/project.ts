export interface Project {
  ProjectId?: number; // Auto-incremented, so it's optional
  ProjectName: string;
  Owner: string;
  CreatedOn: Date;
  Description: string;
  Teams: string; // Adjusted to match your database field name
}
