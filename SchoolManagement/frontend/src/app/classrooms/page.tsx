'use client';

import { useState, useEffect } from 'react';
import { Classroom, Student, Teacher } from '@/types';

export default function ClassroomsPage() {
    const [classrooms, setClassrooms] = useState<Classroom[]>([]);
    const [students, setStudents] = useState<Student[]>([]);
    const [teachers, setTeachers] = useState<Teacher[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [formData, setFormData] = useState({
        roomNumber: '',
        seats: '',
        squareMeters: ''
    });

    useEffect(() => {
        fetchClassrooms();
        fetchStudents();
        fetchTeachers();
    }, []);

    const fetchClassrooms = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/classrooms');
            if (!response.ok) throw new Error('Failed to fetch classrooms');
            const data = await response.json();
            setClassrooms(data);
            setLoading(false);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
            setLoading(false);
        }
    };

    const fetchStudents = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/students');
            if (!response.ok) throw new Error('Failed to fetch students');
            const data = await response.json();
            setStudents(data);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const fetchTeachers = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/teachers');
            if (!response.ok) throw new Error('Failed to fetch teachers');
            const data = await response.json();
            setTeachers(data);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch('http://localhost:5000/api/classrooms', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    roomNumber: formData.roomNumber,
                    seats: parseInt(formData.seats),
                    squareMeters: parseFloat(formData.squareMeters)
                }),
            });

            if (!response.ok) throw new Error('Failed to create classroom');

            await fetchClassrooms();
            setFormData({
                roomNumber: '',
                seats: '',
                squareMeters: ''
            });
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleAddStudent = async (classroomId: number, studentId: number) => {
        try {
            const response = await fetch(`http://localhost:5000/api/classrooms/${classroomId}/students/${studentId}`, {
                method: 'PUT'
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Failed to add student to classroom');
            }

            await fetchClassrooms();
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleAddTeacher = async (classroomId: number, teacherId: number) => {
        try {
            const response = await fetch(`http://localhost:5000/api/classrooms/${classroomId}/teachers/${teacherId}`, {
                method: 'PUT'
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || 'Failed to add teacher to classroom');
            }

            await fetchClassrooms();
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleRemoveStudent = async (classroomId: number, studentId: number) => {
        try {
            const response = await fetch(`http://localhost:5000/api/classrooms/${classroomId}/students/${studentId}`, {
                method: 'DELETE'
            });

            if (!response.ok) throw new Error('Failed to remove student from classroom');

            await fetchClassrooms();
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleRemoveTeacher = async (classroomId: number, teacherId: number) => {
        try {
            const response = await fetch(`http://localhost:5000/api/classrooms/${classroomId}/teachers/${teacherId}`, {
                method: 'DELETE'
            });

            if (!response.ok) throw new Error('Failed to remove teacher from classroom');

            await fetchClassrooms();
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Classrooms Management</h1>

            <form onSubmit={handleSubmit} className="mb-8 space-y-4">
                <div className="grid grid-cols-3 gap-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Room Number</label>
                        <input
                            type="text"
                            value={formData.roomNumber}
                            onChange={(e) => setFormData({ ...formData, roomNumber: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Seats</label>
                        <input
                            type="number"
                            value={formData.seats}
                            onChange={(e) => setFormData({ ...formData, seats: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                            min="1"
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Square Meters</label>
                        <input
                            type="number"
                            value={formData.squareMeters}
                            onChange={(e) => setFormData({ ...formData, squareMeters: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                            min="1"
                            step="0.1"
                        />
                    </div>
                </div>

                <button
                    type="submit"
                    className="mt-4 px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                >
                    Add Classroom
                </button>
            </form>

            <div className="space-y-6">
                {classrooms.map((classroom) => (
                    <div key={classroom.id} className="bg-white shadow rounded-lg p-6">
                        <div className="flex justify-between items-start mb-4">
                            <div>
                                <h2 className="text-xl font-semibold">Room {classroom.roomNumber}</h2>
                                <p className="text-gray-600">
                                    {classroom.seats} seats | {classroom.squareMeters} m²
                                </p>
                            </div>
                        </div>

                        <div className="grid grid-cols-2 gap-4">
                            <div>
                                <h3 className="font-semibold mb-2">Students</h3>
                                <div className="space-y-2">
                                    {classroom.students.map((student) => (
                                        <div key={student.id} className="flex justify-between items-center">
                                            <span>{student.firstName} {student.lastName}</span>
                                            <button
                                                onClick={() => handleRemoveStudent(classroom.id, student.id)}
                                                className="text-red-600 hover:text-red-800"
                                            >
                                                Remove
                                            </button>
                                        </div>
                                    ))}
                                    <select
                                        className="mt-2 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                                        onChange={(e) => handleAddStudent(classroom.id, parseInt(e.target.value))}
                                        value=""
                                    >
                                        <option value="">Add Student...</option>
                                        {students
                                            .filter(s => !classroom.students.some(cs => cs.id === s.id))
                                            .map(student => (
                                                <option key={student.id} value={student.id}>
                                                    {student.firstName} {student.lastName}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                            </div>

                            <div>
                                <h3 className="font-semibold mb-2">Teachers</h3>
                                <div className="space-y-2">
                                    {classroom.teachers.map((teacher) => (
                                        <div key={teacher.id} className="flex justify-between items-center">
                                            <span>{teacher.firstName} {teacher.lastName}</span>
                                            <button
                                                onClick={() => handleRemoveTeacher(classroom.id, teacher.id)}
                                                className="text-red-600 hover:text-red-800"
                                            >
                                                Remove
                                            </button>
                                        </div>
                                    ))}
                                    <select
                                        className="mt-2 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                                        onChange={(e) => handleAddTeacher(classroom.id, parseInt(e.target.value))}
                                        value=""
                                    >
                                        <option value="">Add Teacher...</option>
                                        {teachers
                                            .filter(t => !classroom.teachers.some(ct => ct.id === t.id))
                                            .map(teacher => (
                                                <option key={teacher.id} value={teacher.id}>
                                                    {teacher.firstName} {teacher.lastName}
                                                </option>
                                            ))
                                        }
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
} 