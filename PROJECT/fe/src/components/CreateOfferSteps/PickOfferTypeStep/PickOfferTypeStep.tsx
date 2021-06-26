import { Button } from "antd";
import { Box, Flex } from "rebass";

interface Props {
  onOfferPicked: (offerType: 'buy' | 'trade') => void
}

export const PickOfferTypeStep = ({ onOfferPicked }: Props) => {
  return (
    <Flex width="100%" height="100%" alignItems="center" justifyContent="center">
      <Box mr="1rem">
        <Button type="primary" size="large" onClick={() => onOfferPicked('buy')}>Kup</Button>
      </Box>
      <Button type="primary" size="large" onClick={() => onOfferPicked('trade')}>Wymień</Button>
    </Flex>
  );
}
