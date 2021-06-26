import { Link, useParams } from "react-router-dom";
import useSWR from "swr";
import { Card, Typography, Button } from 'antd';
import { Box, Flex } from 'rebass'
import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { Advert } from "../../types/Advert";
import { Container, Image, GameImage, GamesContainer, NoMarginTitle } from "./AdvertPage.styled";
import { mapConditionToString } from "../../utils/mapConditionToString";
import { LoadingPage } from "../../components/LoadingPage/LoadingPage";

const { Title, Text } = Typography;

export const AdvertPage = () => {
  const { id } = useParams<{ id: string }>()
  const { data, error } = useSWR<Advert>(`/api/adverts/${id}`)

  if (error) {
    return <ErrorComponent error={error} />
  }

  if (!data) {
    return <LoadingPage />
  }

  const title = data.games.map(game => game.title).join(', ')

  return (
    <Container>
      <Image
        alt=""
        src={data.games[0]?.coverPhoto ?? "https://via.placeholder.com/960x540"}
      />
      <Box pt="2rem" mb="4rem">
        <Flex mb="0.5rem" alignItems="center" justifyContent="space-between">
          <NoMarginTitle>{title}</NoMarginTitle>
          <Link to={`/ogloszenia/${data.idAdvert}/nowe`}>
            <Button type="primary" size="large">Złóż ofertę</Button>
          </Link>
        </Flex>
        <Box mb="0.5rem">
          <NoMarginTitle level={3}>Kategoria: {data.category}</NoMarginTitle>
        </Box>
        <Box>
          <Text>Stan: {mapConditionToString(data.gameCondition)}</Text>
        </Box>
        <Text>{data.description}</Text>
      </Box>
      <Box>
        <Title title="h2">Gry w ogłoszeniu</Title>
      </Box>
      <GamesContainer>
        {data.games.map(game => (
          <Card
            key={game.idGame}
            cover={
              <GameImage
                alt=""
                src={game.coverPhoto ?? "https://via.placeholder.com/500x500"}
              />
            }
            >
            <Card.Meta
              title={game.title}
              description={game.description}
            />
          </Card>
        ))}
      </GamesContainer>
    </Container>
  );
}
