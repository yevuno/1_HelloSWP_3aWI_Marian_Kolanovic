import Link from 'next/link';

export default function Home() {
  return (
    <div className="container mx-auto px-4">
      <h1 className="text-4xl font-bold text-center my-8">School Management System</h1>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <Link href="/students" className="block">
          <div className="p-6 bg-white rounded-lg border border-gray-200 hover:shadow-lg transition-shadow">
            <h2 className="text-2xl font-bold mb-2">Students</h2>
            <p className="text-gray-600">Manage student records, enrollments, and academic information.</p>
          </div>
        </Link>

        <Link href="/teachers" className="block">
          <div className="p-6 bg-white rounded-lg border border-gray-200 hover:shadow-lg transition-shadow">
            <h2 className="text-2xl font-bold mb-2">Teachers</h2>
            <p className="text-gray-600">Manage teacher profiles, assignments, and subject areas.</p>
          </div>
        </Link>

        <Link href="/classrooms" className="block">
          <div className="p-6 bg-white rounded-lg border border-gray-200 hover:shadow-lg transition-shadow">
            <h2 className="text-2xl font-bold mb-2">Classrooms</h2>
            <p className="text-gray-600">Manage classrooms, seating capacity, and space allocation.</p>
          </div>
        </Link>
      </div>

      <div className="mt-12">
        <h2 className="text-2xl font-bold mb-4">Quick Actions</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <button className="p-4 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors">
            Add New Student
          </button>
          <button className="p-4 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors">
            Add New Teacher
          </button>
          <button className="p-4 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors">
            Add New Classroom
          </button>
        </div>
      </div>

      <div className="mt-12 mb-8">
        <h2 className="text-2xl font-bold mb-4">System Overview</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div className="p-6 bg-white rounded-lg border border-gray-200">
            <h3 className="text-lg font-semibold mb-2">Total Students</h3>
            <p className="text-3xl font-bold text-indigo-600">0</p>
          </div>
          <div className="p-6 bg-white rounded-lg border border-gray-200">
            <h3 className="text-lg font-semibold mb-2">Total Teachers</h3>
            <p className="text-3xl font-bold text-indigo-600">0</p>
          </div>
          <div className="p-6 bg-white rounded-lg border border-gray-200">
            <h3 className="text-lg font-semibold mb-2">Total Classrooms</h3>
            <p className="text-3xl font-bold text-indigo-600">0</p>
          </div>
        </div>
      </div>
    </div>
  );
}
