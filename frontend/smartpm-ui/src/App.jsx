import { useEffect, useState } from "react";
import { getProjects } from "./services/projectService";
import ProjectList from "./components/ProjectList";

function App() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    async function loadProjects() {
      try {
        const data = await getProjects();
        setProjects(data);
      } catch (error) {
        console.error(error);
      }
    }

    loadProjects();
  }, []);

  return (
    <div>
      <h1>Smart Project Management Platform</h1>

      <ProjectList projects={projects} />
    </div>
  );
}

export default App;