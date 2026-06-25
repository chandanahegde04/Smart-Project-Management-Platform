import { useState } from "react";

function EditProjectForm({ project, onUpdate }) {
  const [name, setName] = useState(project.name);
  const [status, setStatus] = useState(project.status);

  const handleSubmit = async (e) => {
    e.preventDefault();

    await onUpdate(project.id, {
      id: project.id,
      name,
      status
    });
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <input
        value={status}
        onChange={(e) => setStatus(e.target.value)}
      />

      <button type="submit">
        Update
      </button>
    </form>
  );
}

export default EditProjectForm;