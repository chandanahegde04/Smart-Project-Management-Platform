import { useEffect, useState } from "react";

import {
  getProjects,
  createProject,
  updateProject,
  deleteProject,
} from "../services/projectService";

import ProjectForm from "../components/ProjectForm";
import EditProjectForm from "../components/EditProjectForm";

function Projects() {
  const [projects, setProjects] = useState([]);

  async function loadProjects() {
    try {
      const data = await getProjects();
      setProjects(data);
    } catch (error) {
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
    } catch (error) {
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

  async function handleDelete(id) {
    const confirmDelete = window.confirm(
      "Are you sure you want to delete this project?"
    );

    if (!confirmDelete) return;

    try {
      await deleteProject(id);
      await loadProjects();
    } catch (error) {
      console.error(error);
    }
  }

  return (
    <div>
      <h2>Create Project</h2>

      <ProjectForm onCreate={handleCreate} />

      <h2 style={{ marginTop: "40px" }}>Projects</h2>

      {projects.map((project) => (
        <div
          key={project.id}
          style={{
            border: "1px solid gray",
            borderRadius: "8px",
            padding: "15px",
            marginBottom: "20px",
          }}
        >
          <h3>{project.name}</h3>

          <p>Status: {project.status}</p>

          <EditProjectForm
            project={project}
            onUpdate={handleUpdate}
          />

          <button
            onClick={() => handleDelete(project.id)}
            style={{ marginTop: "10px" }}
          >
            Delete
          </button>
        </div>
      ))}
    </div>
  );
}

export default Projects;