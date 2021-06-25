import { Link } from "react-router-dom";
import useSWR from "swr";
import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { IndexAdvert } from "../../types/IndexAdvert";

export const Index = () => {
  const { data, error } = useSWR<IndexAdvert[]>('/api/adverts')

  if (error) {
    return <ErrorComponent error={error} />
  }

  if (!data) {
    return <div>Loading...</div>
  }

  return (
    <>
      {data.map((advert) => (
        <Link to={`/adverts/${advert.idAdvert}`}>
          <pre>
            {JSON.stringify(advert, null, 2)}
          </pre>
        </Link>
      ))}
    </>
  );
}
