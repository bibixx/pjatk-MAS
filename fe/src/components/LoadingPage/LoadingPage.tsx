import { Spin } from "antd";
import { Flex } from "rebass";
import { LoadingOutlined } from '@ant-design/icons';

const indicator = <LoadingOutlined style={{ fontSize: 128 }} spin />;

export const LoadingPage = () => {
  return (
    <Flex width="100%" height="100%" alignItems="center" justifyContent="center" flexDirection="column">
      <Spin size="large" indicator={indicator} />
    </Flex>
  );
}
