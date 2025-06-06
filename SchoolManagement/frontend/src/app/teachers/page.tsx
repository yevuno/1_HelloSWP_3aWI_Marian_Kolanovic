'use client';

import { useState, useEffect } from 'react';
import { Teacher } from '@/types';

export default function TeachersPage() {
    const [teachers, setTeachers] = useState<Teacher[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        dateOfBirth: '',
        email: '',
        teacherId: '',
        subjects: [''],
        room: ''
    });

    useEffect(() => {
        fetchTeachers();
    }, []);

    const fetchTeachers = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/teachers');
            if (!response.ok) {
                throw new Error('Failed to fetch teachers');
            }
            const data = await response.json();
            setTeachers(data);
            setLoading(false);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
            setLoading(false);
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await fetch('http://localhost:5000/api/teachers', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    ...formData,
                    subjects: formData.subjects.filter(subject => subject.trim() !== '')
                }),
            });

            if (!response.ok) {
                throw new Error('Failed to create teacher');
            }

            await fetchTeachers();
            setFormData({
                firstName: '',
                lastName: '',
                dateOfBirth: '',
                email: '',
                teacherId: '',
                subjects: [''],
                room: ''
            });
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleDelete = async (id: number) => {
        try {
            const response = await fetch(`http://localhost:5000/api/teachers/${id}`, {
                method: 'DELETE',
            });

            if (!response.ok) {
                throw new Error('Failed to delete teacher');
            }

            await fetchTeachers();
        } catch (err) {
            setError(err instanceof Error ? err.message : 'An error occurred');
        }
    };

    const handleAddSubject = () => {
        setFormData({
            ...formData,
            subjects: [...formData.subjects, '']
        });
    };

    const handleSubjectChange = (index: number, value: string) => {
        const newSubjects = [...formData.subjects];
        newSubjects[index] = value;
        setFormData({
            ...formData,
            subjects: newSubjects
        });
    };

    const handleRemoveSubject = (index: number) => {
        setFormData({
            ...formData,
            subjects: formData.subjects.filter((_, i) => i !== index)
        });
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Teachers Management</h1>

            <form onSubmit={handleSubmit} className="mb-8 space-y-4">
                <div className="grid grid-cols-2 gap-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-700">First Name</label>
                        <input
                            type="text"
                            value={formData.firstName}
                            onChange={(e) => setFormData({ ...formData, firstName: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Last Name</label>
                        <input
                            type="text"
                            value={formData.lastName}
                            onChange={(e) => setFormData({ ...formData, lastName: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Date of Birth</label>
                        <input
                            type="date"
                            value={formData.dateOfBirth}
                            onChange={(e) => setFormData({ ...formData, dateOfBirth: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Email</label>
                        <input
                            type="email"
                            value={formData.email}
                            onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Teacher ID</label>
                        <input
                            type="text"
                            value={formData.teacherId}
                            onChange={(e) => setFormData({ ...formData, teacherId: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Room</label>
                        <input
                            type="text"
                            value={formData.room}
                            onChange={(e) => setFormData({ ...formData, room: e.target.value })}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                            required
                        />
                    </div>
                </div>

                <div>
                    <label className="block text-sm font-medium text-gray-700">Subjects</label>
                    {formData.subjects.map((subject, index) => (
                        <div key={index} className="flex gap-2 mt-2">
                            <input
                                type="text"
                                value={subject}
                                onChange={(e) => handleSubjectChange(index, e.target.value)}
                                className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500"
                                placeholder="Enter subject"
                                required
                            />
                            {index > 0 && (
                                <button
                                    type="button"
                                    onClick={() => handleRemoveSubject(index)}
                                    className="px-2 py-1 bg-red-600 text-white rounded-md hover:bg-red-700"
                                >
                                    Remove
                                </button>
                            )}
                        </div>
                    ))}
                    <button
                        type="button"
                        onClick={handleAddSubject}
                        className="mt-2 px-4 py-2 bg-green-600 text-white rounded-md hover:bg-green-700"
                    >
                        Add Subject
                    </button>
                </div>

                <button
                    type="submit"
                    className="mt-4 px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                >
                    Add Teacher
                </button>
            </form>

            <div className="overflow-x-auto">
                <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-50">
                        <tr>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Name</th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Teacher ID</th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Subjects</th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Room</th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
                        </tr>
                    </thead>
                    <tbody className="bg-white divide-y divide-gray-200">
                        {teachers.map((teacher) => (
                            <tr key={teacher.id}>
                                <td className="px-6 py-4 whitespace-nowrap">
                                    {teacher.firstName} {teacher.lastName}
                                </td>
                                <td className="px-6 py-4 whitespace-nowrap">{teacher.teacherId}</td>
                                <td className="px-6 py-4 whitespace-nowrap">{teacher.subjects.join(', ')}</td>
                                <td className="px-6 py-4 whitespace-nowrap">{teacher.room}</td>
                                <td className="px-6 py-4 whitespace-nowrap">
                                    <button
                                        onClick={() => handleDelete(teacher.id)}
                                        className="text-red-600 hover:text-red-900"
                                    >
                                        Delete
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
} 