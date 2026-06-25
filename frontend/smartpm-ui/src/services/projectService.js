const API_URL = "http://localhost:5256/api/projects";

export async function getProjects() {
  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error("Failed to fetch projects");
  }

  return await response.json();
}

export async function createProject(project) {
  const response = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(project)
  });

  if (!response.ok) {
    throw new Error("Failed to create project");
  }

  return await response.json();
}