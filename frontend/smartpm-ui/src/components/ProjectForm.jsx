import { useState } from "react";

function ProjectForm({ onCreate }) {
  const [name, setName] = useState("");
  const [status, setStatus] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    await onCreate({
      name,
      status
    });

    setName("");
    setStatus("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create Project</h2>

      <div>
        <input
          type="text"
          placeholder="Project Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </div>

      <div>
        <input
          type="text"
          placeholder="Status"
          value={status}
          onChange={(e) => setStatus(e.target.value)}
        />
      </div>

      <button type="submit">
        Create Project
      </button>
    </form>
  );
}

export default ProjectForm;