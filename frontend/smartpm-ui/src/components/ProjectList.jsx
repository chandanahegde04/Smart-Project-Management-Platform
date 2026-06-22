function ProjectList({ projects }) {
  return (
    <div>
      <h2>Projects</h2>

      <ul>
        {projects.map(project => (
          <li key={project.id}>
            {project.name} - {project.status}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ProjectList;