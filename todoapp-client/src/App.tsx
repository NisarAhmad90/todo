// File: TodoApp.Client/src/App.tsx
import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

type TodoTask = {
  id: number;
  title: string;
  deadline: string;
  isCompleted: boolean;
};

const App: React.FC = () => {
  const [tasks, setTasks] = useState<TodoTask[]>([]);
  const [title, setTitle] = useState('');
  const [deadline, setDeadline] = useState('');

  const API_BASE = "https://localhost:7060/api/todotasks";

  const fetchTasks = async () => {
    const res = await fetch(API_BASE);
    const data = await res.json();
    setTasks(data);
  };

  const addTask = async () => {
    await fetch(API_BASE, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ title, deadline }),
    });
    setTitle('');
    setDeadline('');
    fetchTasks();
  };

    const toggleTask = async (id: number) => {
    await fetch(`${API_BASE}/${id}/toggle`, { method: 'PUT' });
    fetchTasks();

    };

  const deleteTask = async (id: number) => {
    await fetch(`${API_BASE}/${id}`, { method: 'DELETE' });
    fetchTasks();
  };

  useEffect(() => {
    fetchTasks();
  }, []);

 
const isOverdue = (deadline: string | null, isCompleted: boolean): boolean => {
  if (!deadline || isCompleted) return false;

  const now = new Date();
  const dueDate = new Date(deadline);

  return dueDate.getTime() < now.getTime();
};



  return (
    <div className="container mt-4">
      <h2> ToDo App</h2>
      <div className="mb-3">
        <input
          className="form-control mb-2"
          placeholder="Enter task title (min 10 chars)"
          value={title}
          onChange={e => setTitle(e.target.value)}
        />
        <input
          className="form-control mb-2"
          type="date"
          value={deadline}
          onChange={e => setDeadline(e.target.value)}
        />
        <button className="btn btn-primary" onClick={addTask}>Add Task</button>
      </div>

      <table className="table table-bordered">
        <thead className="table-dark">
          <tr>
            <th>Title</th>
            <th>Deadline</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {tasks.map(task => (
            <tr className={isOverdue(task.deadline, task.isCompleted) ? 'table-danger' : ''}>
              <td>{task.title}</td>
              <td>{new Date(task.deadline).toLocaleDateString()}</td>
               <td>{task.isCompleted ? '✅ Completed' : '🕒 Pending'}</td>
              <td>
                <button className="btn btn-sm btn-warning me-2" onClick={() => toggleTask(task.id)}>
                  Toggle
                </button>
                <button className="btn btn-sm btn-danger" onClick={() => deleteTask(task.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default App;
