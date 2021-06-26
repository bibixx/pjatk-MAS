export const fetcher = async (url: string, init?: RequestInit) => {
  const response = await fetch(`http://localhost:5000${url}`, init);

  if (response.ok) {
    try {
      return await response.json();
    } catch (error) {
      return null;
    }
  }

  throw new Error(response.statusText);
}
