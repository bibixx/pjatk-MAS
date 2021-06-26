import { Typography, Button } from 'antd';
import { Box, Flex } from 'rebass';
const { Title } = Typography;

interface Props {
  price: number;
  onConfirm: () => void
  onCancel: () => void
}

export const BuyoutConfirmationStep = ({ price, onConfirm, onCancel }: Props) => {
  return (
    <Box mt="2rem">
      <Title>Czy na pewno chcesz zaproponować {price} PLN?</Title>
      <Flex mt="1rem">
        <Box mr="1rem">
          <Button type="primary" size="large" onClick={onConfirm}>Tak</Button>
        </Box>
        <Button type="primary" size="large" danger onClick={onCancel}>Nie</Button>
      </Flex>
    </Box>
  );
}
