import { PUBLISHER_URL } from "@/global/urls";
import { listProviderFactory } from "./factories/listsFactory";
import { useContext } from "react";
import Publisher from "@/models/publisher";

const { context, ProviderElement: PublishersListProvider } = listProviderFactory<Publisher>({
  baseUrl: PUBLISHER_URL,
});

const usePublishersList = () => useContext(context);

export { usePublishersList, PublishersListProvider };
