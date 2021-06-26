import { Link } from "react-router-dom";
import { Card } from 'antd';
import useSWR from "swr";
import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { IndexAdvert } from "../../types/IndexAdvert";
import { Container, Image } from "./AdsListPage.styled";
import { LoadingPage } from "../../components/LoadingPage/LoadingPage";

export const AdsListPage = () => {
  const { data, error } = useSWR<IndexAdvert[]>('/api/adverts')

  if (error) {
    return <ErrorComponent error={error} />
  }

  if (!data) {
    return <LoadingPage />
  }

  return (
    <>
      <Container>
        {data.map((advert) => (
          <Link to={`/ogloszenia/${advert.idAdvert}`} key={advert.idAdvert}>
            <Card
              hoverable
              cover={
                <Image
                  alt=""
                  src={advert.games[0]?.coverPhoto ?? "https://via.placeholder.com/500x500"}
                />
              }
            >
              <Card.Meta title={advert.games.map(game => game.title).join(', ')} />
            </Card>
          </Link>
        ))}
      </Container>
    </>
  );
}
