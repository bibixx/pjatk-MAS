import { Typography, Button, Card } from 'antd';
import { Box, Flex } from 'rebass';
import { Game } from "../../../types/Game";
import { GameImage, GamesContainer } from './TradeConfirmationStep.styled';

const { Title } = Typography;

interface Props {
  selectedGames: Game[]
  onConfirm: () => void
  onCancel: () => void
}

export const TradeConfirmationStep = ({ selectedGames, onConfirm, onCancel }: Props) => {
  return (
    <Box mt="2rem">
      <Title>Czy na pewno chcesz zaproponować te gry?</Title>
      <GamesContainer>
        {selectedGames.map(game => (
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
      <Flex mt="1rem">
        <Box mr="1rem">
          <Button type="primary" size="large" onClick={onConfirm}>Tak</Button>
        </Box>
        <Button type="primary" size="large" danger onClick={onCancel}>Nie</Button>
      </Flex>
    </Box>
  );
}
