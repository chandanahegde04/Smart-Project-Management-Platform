const API_URL = "http://localhost:5256/api/projects";

export async function getProjects(token) {
  const response = await fetch(API_URL, {
    headers: {
      Authorization: `Bearer ${token}`
    }
  });

  return await response.json();
}