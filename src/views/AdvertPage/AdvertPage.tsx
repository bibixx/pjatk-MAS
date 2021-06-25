import { useParams } from "react-router-dom";
import useSWR from "swr";
import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { Advert } from "../../types/Advert";

export const AdvertPage = () => {
  const { id } = useParams<{ id: string }>()
  const { data, error } = useSWR<Advert>(`/api/adverts/${id}`)

  if (error) {
    return <ErrorComponent error={error} />
  }

  if (!data) {
    return <div>Loading...</div>
  }

  return (
    <>
      <pre>
        {JSON.stringify(data, null, 2)}
      </pre>
    </>
  );
}
