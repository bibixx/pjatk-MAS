import { Typography } from "antd";
import { Box, Flex } from "rebass";
import { ExclamationCircleTwoTone } from '@ant-design/icons';

interface Props {
  error: Error
}

export const ErrorComponent = ({ error }: Props) => {
  console.error(error);

  return (
    <Flex width="100%" height="100%" alignItems="center" justifyContent="center" flexDirection="column">
      <Typography.Title>Wystąpił błąd.</Typography.Title>
      <Typography.Title level={3} style={{ marginTop: 0 }}>Prosimy spróbuj ponownie później.</Typography.Title>

      <Box mt="1rem">
        <ExclamationCircleTwoTone style={{ fontSize: '7rem' }} twoToneColor="#ee0000"  />
      </Box>
    </Flex>
  );
}
