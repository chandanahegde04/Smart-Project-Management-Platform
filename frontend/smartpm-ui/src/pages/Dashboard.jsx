import { useEffect, useState } from "react";
import { getProjects } from "../services/projectService";

function Dashboard() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    async function loadProjects() {
      try {
        const data = await getProjects();
        setProjects(data);
      } catch (err) {
        console.error(err);
      }
    }

    loadProjects();
  }, []);

  const total = projects.length;

  const completed = projects.filter(
    (p) => p.status === "Completed"
  ).length;

  const inProgress = projects.filter(
    (p) => p.status === "In Progress"
  ).length;

  return (
    <div>
      <h2>Dashboard</h2>

      <h3>Total Projects: {total}</h3>

      <h3>Completed: {completed}</h3>

      <h3>In Progress: {inProgress}</h3>
    </div>
  );
}

export default Dashboard;