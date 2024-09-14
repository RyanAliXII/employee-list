export const serverRequest = (path: string, init?: RequestInit) => {
  const baseUrl = "http://localhost:5010";
  let url = "";
  if (path.startsWith("/")) {
    url = `${baseUrl}${path}`;
  } else {
    url = `${baseUrl}/${path}`;
  }
  return fetch(url, init);
};
