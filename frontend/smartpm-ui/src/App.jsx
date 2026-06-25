import { useEffect, useState } from "react";
import {
  getProjects,
  createProject
} from "./services/projectService";

import ProjectList from "./components/ProjectList";
import ProjectForm from "./components/ProjectForm";

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

  return (
    <div>
      <h1>Smart Project Management Platform</h1>

      <ProjectForm
        onCreate={handleCreate}
      />

      <ProjectList
        projects={projects}
      />
    </div>
  );
}

export default App;