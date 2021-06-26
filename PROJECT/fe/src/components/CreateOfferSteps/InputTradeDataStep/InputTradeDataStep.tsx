import {
  Form,
  Button,
  Select,
  Typography
} from 'antd';
import { useState } from 'react';
import { Box } from 'rebass';
import { Game } from '../../../types/Game';

interface Props {
  onConfirm: (gamesPicked: number[]) => void
  availableGames: Game[]
}

export const InputTradeDataStep = ({ onConfirm, availableGames }: Props) => {
  const [selectedGames, setSelectedGames] = useState<number[]>([]);

  const onSelectChange = (index: number) => (value: number) => {
    console.log(value);

    setSelectedGames([
      ...selectedGames.slice(0, index),
      value,
      ...selectedGames.slice(index + 1),
    ])
  }

  const onFinish = () => {
    onConfirm(selectedGames)
  }

  return (
    <Box mt="2rem">
      <Typography.Title>Jakie gry chcesz zaproponować?</Typography.Title>
      <Form
        labelCol={{ span: 4 }}
        wrapperCol={{ span: 14 }}
        layout="horizontal"
      >
        {Array.from({ length: selectedGames.length + 1 }).map((_, i) => (
          <Form.Item label={`Gra ${i + 1}`} key={i}>
            <Select
              onChange={onSelectChange(i)}
              value={availableGames.find(({ idGame }) => idGame === selectedGames[i])?.title as any}
              placeholder="Wybierz grę"
              options={
                availableGames
                  .filter(game => !selectedGames.includes(game.idGame))
                  .map((game => ({
                    value: game.idGame,
                    label: game.title
                  })))
              }
            />
          </Form.Item>
        ))}
        <Form.Item>
          <Button onClick={onFinish} htmlType="submit" type="primary">Dalej</Button>
        </Form.Item>
      </Form>
    </Box>
  );
}
