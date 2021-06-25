export const fetcher = async (url: string, init?: RequestInit) => {
  const response = await fetch(`http://localhost:5000${url}`, init);

  if (response.ok) {
    const data = await response.json();

    return data;
  }

  throw new Error(response.statusText);
}
