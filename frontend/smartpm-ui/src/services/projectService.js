const API_URL = "http://localhost:5256/api/projects";

export async function getProjects() {
  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error("Failed to fetch projects");
  }

  return await response.json();
}