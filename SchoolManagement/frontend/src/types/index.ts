export interface Teacher {
    id: number;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    email: string;
    teacherId: string;
    subjects: string[];
    room: string;
}

export interface Student {
    id: number;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    email: string;
    studentId: string;
    grade: number;
}

export interface Classroom {
    id: number;
    roomNumber: string;
    seats: number;
    squareMeters: number;
    students: Student[];
    teachers: Teacher[];
} 