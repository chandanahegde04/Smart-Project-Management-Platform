import { useEffect, useState } from "react";
import {
  getProjects,
  createProject,
  updateProject
} from "./services/projectService";

import ProjectForm from "./components/ProjectForm";
import EditProjectForm from "./components/EditProjectForm";

function App() {
  const [projects, setProjects] = useState([]);

  async function loadProjects() {
    try {
      const data = await getProjects();
      setProjects(data);
    }
    catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    loadProjects();
  }, []);

  async function handleCreate(project) {
    try {
      await createProject(project);

      await loadProjects();
    }
    catch (error) {
      console.error(error);
    }
  }
  async function handleUpdate(id, project) {
  try {
    await updateProject(id, project);
    await loadProjects();
  } catch (error) {
    console.error(error);
  }
}

  return (
  <div>
    <h1>Smart Project Management Platform</h1>

    <ProjectForm
      onCreate={handleCreate}
    />

    <h2>Projects</h2>

    {projects.map(project => (
      <div key={project.id}>
        <p>
          {project.name} - {project.status}
        </p>

        <EditProjectForm
          project={project}
          onUpdate={handleUpdate}
        />
      </div>
    ))}
  </div>
);
}

export default App;