import { Typography } from "antd";
import { Flex } from "rebass";
import { CheckCircleTwoTone } from '@ant-design/icons';

export const SuccessStep = () => {
  return (
    <Flex width="100%" height="100%" alignItems="center" justifyContent="center" flexDirection="column">
      <Typography.Title>Pomyślnie stworzono ofertę transakcji!</Typography.Title>
      <CheckCircleTwoTone style={{ fontSize: '7rem' }} twoToneColor="#72C040"  />
    </Flex>
  );
}
