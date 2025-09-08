export interface Course {
  id: number;
  title: string;
  category: string;
  durationHours: number;
  level: 'Beginner' | 'Intermediate' | 'Advanced';
}